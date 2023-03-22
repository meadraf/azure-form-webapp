import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient, HttpParams} from "@angular/common/http";
import {getBaseUrl} from "../../main";

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent {

  email: string = "";
  file: File | null = null;

  constructor(private http: HttpClient, @Inject('BASE_URL')  private baseUrl: string) {

  }

  onFileSelected(event:any): void {
    this.file = event.target.files[0];
  }

  onSubmit(): void {
    const formData = new FormData();
    // @ts-ignore
    formData.append('file', this.file);
    const params = new HttpParams().set('email', this.email);
    this.http.post( "https://localhost:7291/" + 'blob/upload', formData, {params})
      .subscribe(response => {
        console.log(response);
      });
  }
}
