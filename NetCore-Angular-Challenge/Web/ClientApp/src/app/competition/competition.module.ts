import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CompetitionComponent } from "./competition/competition.component";
import { CompetitionRoutingModule } from "./competition-route.module";
import { CompetitionDetailComponent } from "./competition-detail/competition-detail.component";
import { SharedResourcesModule } from '../shared/shared-resources.module';

@NgModule({
  declarations: [CompetitionComponent, CompetitionDetailComponent],
  imports: [CommonModule, CompetitionRoutingModule, SharedResourcesModule],
  exports: [CompetitionComponent]
})
export class CompetitionModule {}
