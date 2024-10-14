// login.component.ts
import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../auth/auth.service';

interface BookFilterModel {
  SortData: string;
  Random: boolean;
  Title: string;
  Author: string;
  Availability: number;
}
interface FeaturedBook {
  id: number;
  title: string;
  author: string;
  description: string;
  coverImagePath: string;
  averageRate: number;
  availability: boolean;
}

@Component({
  selector: 'app-root',
  templateUrl: './booklist.component.html',
  styleUrl: 'booklist.component.css'
})

export class BookListComponent {
  constructor(private http: HttpClient, private authService: AuthService, private router: Router) { }
  bookFilterModel: BookFilterModel = {
    SortData: "", Random: true, Title: "", Author: "", Availability: 2
  };
  featuredBooks: FeaturedBook[] = [];
  isLibrarian: boolean = this.authService.isLibrarian();
  isCustomer: boolean = this.authService.isCustomer();

  ngOnInit() {
    this.getFeaturedBooks();
  }

  getFeaturedBooks() {
    const params = new HttpParams()
      .set('SortData', this.bookFilterModel.SortData)
      .set('Random', this.bookFilterModel.Random)
      .set('Title', this.bookFilterModel.Title)
      .set('Author', this.bookFilterModel.Author)
      .set('Availability', this.bookFilterModel.Availability);
    this.http.get<FeaturedBook[]>('/book/getbooks', { params }).subscribe(
      (result) => {
        this.featuredBooks = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  search(): void {
    this.bookFilterModel.Random = false;

    const params = new HttpParams()
      .set('SortData', this.bookFilterModel.SortData)
      .set('Random', this.bookFilterModel.Random)
      .set('Title', this.bookFilterModel.Title)
      .set('Author', this.bookFilterModel.Author)
      .set('Availability', this.bookFilterModel.Availability);
    this.http.get<FeaturedBook[]>('/book/getbooks', { params }).subscribe(
      (result) => {
        this.featuredBooks = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getBook(event: any): void {
    localStorage.setItem('currentbookid', event.target.value);
    this.router.navigate(['../bookdetail']);
  }

  addBook() {
    localStorage.removeItem('currentbookid');
    this.router.navigate(['../bookdetail']);
  }

  checkoutbook(event: any) {
    this.http.post('/book/checkoutbook', event.target.value).subscribe(
      (result) => {
        this.search();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  returnbook(event: any) {
    this.http.post('/book/returnbook', event.target.value).subscribe(
      (result) => {
        this.search();
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
