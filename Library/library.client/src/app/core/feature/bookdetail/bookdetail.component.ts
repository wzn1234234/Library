// login.component.ts
import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, ViewChild, ElementRef } from '@angular/core';
import { AuthService } from '../../auth/auth.service';
import { Router } from '@angular/router';

interface BookReviewModel {
  BookId: number;
  Review: string;
  Rate: number;
}
interface BookReviewDetailModel {
  BookId: number;
  Review: string;
  Rate: number;
  FirstName: string;
  LastName: string;
}
interface BookDetailModel {
  Id: number;
  Title: string;
  Author: string;
  Description: string;
  CoverImagePath: string;
  AverageRate: number;
  Availability: number;
  Publisher: string;
  PublicationDate: Date | null;
  Category: string;
  ISBN: string;
  PageCount: number;
  CoverImage: File | null;
  UserBookReviews: BookReviewDetailModel[]
}

@Component({
  selector: 'app-root',
  templateUrl: './bookdetail.component.html',
})

export class BookDetailComponent {
  constructor(private http: HttpClient, private authService: AuthService, private router: Router) { }
  currentBookId: number = 0;
  book: BookDetailModel = {
    Id: 0,
    Title: "",
    Author: "",
    Description: "",
    CoverImagePath: "",
    AverageRate: 0,
    Availability: 1,
    Publisher: "",
    PublicationDate: null,
    Category: "",
    ISBN: "",
    PageCount: 0,
    CoverImage: null,
    UserBookReviews: []
  };
  review: BookReviewModel = { BookId: 0, Review: "", Rate: 0 };
  isLibrarian: boolean = this.authService.isLibrarian();
  isCustomer: boolean = this.authService.isCustomer();

  ngOnInit() {
    this.currentBookId = localStorage.getItem('currentbookid') ==null ? 0 : Number(localStorage.getItem('currentbookid'));
    this.review = { BookId: this.currentBookId, Review: "", Rate: 0 };

    this.getBookDetail();
  }

  getBookDetail() {
    if (this.currentBookId != 0) {
      const params = new HttpParams()
        .set('bookId', this.currentBookId);
      this.http.get<BookDetailModel>('/getbook', { params }).subscribe(
        (result) => {
          this.book = result;
        },
        (error) => {
          console.error(error);
        }
      );
    }
  }

  getAddBookPage() {
    this.book = {
      Id: 0,
      Title: "",
      Author: "",
      Description: "",
      CoverImagePath: "",
      AverageRate: 0,
      Availability: 1,
      Publisher: "",
      PublicationDate: null,
      Category: "",
      ISBN: "",
      PageCount: 0,
      CoverImage: null,
      UserBookReviews: []
    }
  }

  addBook() {
    this.http.post<boolean>('/book/addbook', this.book).subscribe(
      (result) => {
        if (result) {
          console.log("added successfully");
        } else {
          console.log("added failed");
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }

  editBook() {
    this.http.post<boolean>('/book/editbook', this.book).subscribe(
      (result) => {
        if (result) {
          console.log("edited successfully");
        } else {
          console.log("edited failed");
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }

  removeBook() {
    this.http.post<boolean>('/book/removebook', this.currentBookId).subscribe(
      (result) => {
        if (result) {
          console.log("removed successfully");
        } else {
          console.log("removed failed");
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }

  checkoutbook() {
    this.http.post<BookDetailModel>('/book/checkoutbook', this.currentBookId).subscribe(
      (result) => {
        this.book = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  returnbook() {
    this.http.post<BookDetailModel>('/book/returnbook', this.currentBookId).subscribe(
      (result) => {
        this.book = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  reviewbook() {
    this.http.post<BookDetailModel>('/book/reviewbook', this.review).subscribe(
      (result) => {
        this.book = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
