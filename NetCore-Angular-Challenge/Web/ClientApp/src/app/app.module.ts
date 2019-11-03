import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/Http';
import { CompetitionModule } from './competition/competition.module';
import { BlockUIModule } from 'ng-block-ui';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    BlockUIModule.forRoot(),
    ToastrModule.forRoot(),
    CompetitionModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
