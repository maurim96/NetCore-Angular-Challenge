import { Component, OnInit, OnDestroy } from "@angular/core";
import { CompetitionStoreService } from "../../core/stores/competition-store.service";
import { Competition, CompetitionApiResponse } from "../../models/Competition";
import { BlockUI, NgBlockUI } from "ng-block-ui";
import { CompetitionService } from "src/app/core/services/competition.service";
import { ToastrService } from "ngx-toastr";
import { Router } from "@angular/router";
import { Subscription } from "rxjs";

@Component({
  selector: "app-competition",
  templateUrl: "./competition.component.html",
  styleUrls: ["./competition.component.css"]
})
export class CompetitionComponent implements OnInit, OnDestroy {
  @BlockUI() blockUI: NgBlockUI;
  public competitions: Competition[];
  private importedCompetitionsIds: number[] = [];
  public apiCompetitions: Competition[];
  //These are the competitions that my free account on Football-Data Api allow me to get info
  private availableCompetitions = [2001, 2002, 2003, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2021];
  private storeSubscription: Subscription;
  private apiSubscription: Subscription;
  private importSubscription: Subscription;

  constructor(
    private competitionStore: CompetitionStoreService,
    private competitionService: CompetitionService,
    private toastr: ToastrService,
    private router: Router
  ) {
    this.blockUI.start("Loading...");
  }

  ngOnInit() {
    this.getInitialData();
  }

  ngOnDestroy() {
    this.storeSubscription.unsubscribe();
    this.apiSubscription.unsubscribe();
  }

  getInitialData() {
    this.storeSubscription = this.competitionStore.competitions$.subscribe(competitions => {
      this.competitions = competitions;
      this.setImportedCompetitionsIds();
      this.apiSubscription = this.competitionService.GetApiCompetitions().subscribe(
        (res: CompetitionApiResponse) => {
          this.blockUI.stop();
          this.toastr.success("Competitions successfully loaded", "Success");
          this.apiCompetitions = res.competitions.filter(x => this.availableCompetitions.includes(x.id));
        },
        err => {
          this.blockUI.stop();
          this.toastr.error("Something wrong happend. Try Again", "Error");
        }
      );
    });
  }

  setImportedCompetitionsIds() {
    this.competitions.map(x => this.importedCompetitionsIds.push(x.id));
  }

  viewDetails(id: number) {
    this.router.navigateByUrl(`competition/${id}`);
  }

  importCompetition(id: number) {
    this.blockUI.start("Loading...");
    this.competitionService.ImportCompetition(id).subscribe(
      (res: string) => {
        this.competitionStore.fetchCompetitions();
        this.blockUI.stop();
        this.toastr.success(res, "Success");
      },
      err => {
        this.blockUI.stop();
        this.toastr.error(err.error, "Error");
      }
    );
  }
}
