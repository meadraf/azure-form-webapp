import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import {FormComponent} from "./form/form.component";


@NgModule({
    declarations: [
        AppComponent,
        FormComponent,

    ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

