// login.component.ts
import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, ViewChild, ElementRef } from '@angular/core';
import { AuthService } from '../../auth/auth.service';
import { Router } from '@angular/router';

interface BookReviewModel {
  bookId: number;
  review: string;
  rate: number;
}
interface BookReviewDetailModel {
  bookId: number;
  review: string;
  rate: number;
  firstName: string;
  lastName: string;
}
interface BookDetailModel {
  id: number;
  title: string;
  author: string;
  description: string;
  coverImagePath: string;
  averageRate: number;
  availability: number;
  publisher: string;
  publicationDate: Date | null;
  category: string;
  isbn: string;
  pageCount: number;
  coverImage: File | null;
  userBookReviews: BookReviewDetailModel[]
}

@Component({
  selector: 'app-root',
  templateUrl: './bookdetail.component.html',
})

export class BookDetailComponent {
  constructor(private http: HttpClient, private authService: AuthService, private router: Router) { }
  currentBookId: number = 0;
  book: BookDetailModel = {
    id: 0,
    title: "",
    author: "",
    description: "",
    coverImagePath: "",
    averageRate: 0,
    availability: 1,
    publisher: "",
    publicationDate: null,
    category: "",
    isbn: "",
    pageCount: 0,
    coverImage: null,
    userBookReviews: []
  };
  review: BookReviewModel = { bookId: 0, review: "", rate: 0 };
  isLibrarian: boolean = this.authService.isLibrarian();
  isCustomer: boolean = this.authService.isCustomer();
  addMode: boolean = false;

  ngOnInit() {
    this.currentBookId = localStorage.getItem('currentbookid') ==null ? 0 : Number(localStorage.getItem('currentbookid'));
    this.review = { bookId: this.currentBookId, review: "", rate: 0 };

    this.getBookDetail();
    this.addMode = this.book.id == 0;
  }

  getBookDetail() {
    if (this.currentBookId != 0) {
      const params = new HttpParams()
        .set('bookId', this.currentBookId);
      this.http.get<BookDetailModel>('/book/getbook', { params }).subscribe(
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
      id: 0,
      title: "",
      author: "",
      description: "",
      coverImagePath: "",
      averageRate: 0,
      availability: 1,
      publisher: "",
      publicationDate: null,
      category: "",
      isbn: "",
      pageCount: 0,
      coverImage: null,
      userBookReviews: []
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
