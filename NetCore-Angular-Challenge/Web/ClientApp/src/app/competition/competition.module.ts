import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CompetitionComponent } from "./competition/competition.component";
import { CompetitionRoutingModule } from "./competition-route.module";
import { DataViewModule } from "primeng/dataview";
import { SharedModule, PanelModule, ButtonModule } from "primeng/primeng";
import { CompetitionCarrouselComponent } from './competition-carrousel/competition-carrousel.component';

@NgModule({
  declarations: [CompetitionComponent, CompetitionCarrouselComponent],
  imports: [CommonModule, CompetitionRoutingModule, DataViewModule, SharedModule, PanelModule, ButtonModule ],
  exports: [CompetitionComponent]
})
export class CompetitionModule {}
