import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompetitionComponent } from './competition.component';

@NgModule({
  declarations: [CompetitionComponent],
  imports: [
    CommonModule,
  ],
  exports: [CompetitionComponent]
})
export class CompetitionModule { }
