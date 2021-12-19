import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import { catchError, retry } from "rxjs/operators";
import { environment } from "../environments/environment";
import { Item } from "../models/item";

//@Injectable({
//  providedIn: 'root'
//})

export class ItemServices {

  myAppUrl: string;
  myApiUrl: string

  httpOptions = {
        headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  }

  constructor(private http: HttpClient) {
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/Item';
  }

  getItems(): Observable<Item[]> {

    var list = this.http.get<Item[]>(this.myAppUrl + this.myApiUrl)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      );

    return list;
  }

  getItem(id: number): Observable<Item> {

    var edit = this.http.get<Item>(this.myAppUrl + this.myApiUrl + '/' + id)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
    );

    return edit;
  }

  saveItem(item): Observable<Item> {

    var save = this.http.post<Item>(this.myAppUrl + this.myApiUrl, JSON.stringify(item), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
      )

    return save;
  }

  updateItem(id: number, item): Observable<Item> {

    var update = this.http.put<Item>(this.myAppUrl + this.myApiUrl + id, JSON.stringify(item), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
    );

    return update;
  }

  deleteItem(id: number): Observable<Item> {

    var deleteItem = this.http.delete<Item>(this.myAppUrl + this.myApiUrl + id)
      .pipe(
        retry(1),
        catchError(this.errorHandler)
    );

    return deleteItem;
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);

  }
}
