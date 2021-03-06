import { CompetitionComponent } from "./competition/competition.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AuthGuard } from "../core/guards/auth.guard";
import { CompetitionDetailComponent } from "./competition-detail/competition-detail.component";

const routes: Routes = [
  {
    path: "",
    component: CompetitionComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "competition/:id",
    component: CompetitionDetailComponent,
    canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompetitionRoutingModule {}
