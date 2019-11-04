import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CarrouselComponent } from "./carrousel/carrousel.component";
import { SharedModule, PanelModule, ButtonModule } from "primeng/primeng";
import { DataViewModule } from "primeng/dataview";

@NgModule({
  declarations: [CarrouselComponent],
  imports: [CommonModule, DataViewModule, SharedModule, PanelModule, ButtonModule],
  exports: [CarrouselComponent]
})
export class SharedResourcesModule {}
