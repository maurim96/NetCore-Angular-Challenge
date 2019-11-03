import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompetitionComponent } from './competition/competition.component';
import { CompetitionRoutingModule } from './competition-route.module';

@NgModule({
  declarations: [CompetitionComponent],
  imports: [
    CommonModule,
    CompetitionRoutingModule
  ],
  exports: [CompetitionComponent]
})
export class CompetitionModule { }
