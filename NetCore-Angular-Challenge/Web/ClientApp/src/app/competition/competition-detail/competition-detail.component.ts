import { Component, OnInit, OnDestroy } from "@angular/core";
import { Team } from "src/app/models/Model";
import { CompetitionService } from "src/app/core/services/competition.service";
import { ActivatedRoute } from "@angular/router";
import { NgBlockUI, BlockUI } from "ng-block-ui";
import { Competition } from "src/app/models/Competition";
import { ToastrService } from "ngx-toastr";
import { Subscription } from "rxjs";

@Component({
  selector: "app-competition-detail",
  templateUrl: "./competition-detail.component.html",
  styleUrls: ["./competition-detail.component.css"]
})
export class CompetitionDetailComponent implements OnInit, OnDestroy {
  @BlockUI() blockUI: NgBlockUI;
  public teams: Team[];
  public competition: Competition;
  private competitionSubscription: Subscription;
  constructor(
    private _competitionService: CompetitionService,
    private _activatedRoute: ActivatedRoute,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.blockUI.start("Loading...");
    let id = this._activatedRoute.snapshot.paramMap.get("id");
    this.competitionSubscription = this._competitionService.GetCompetitionById(id).subscribe((response: any) => {
      this.teams = response.teams;
      this.competition = response.competition;
      this.blockUI.stop();
    });
  }

  ngOnDestroy() {
    this.competitionSubscription.unsubscribe();
  }

  viewDetails(id: number) {
    this.toastr.warning("Functionality not implemented", "Sorry");
  }
}
