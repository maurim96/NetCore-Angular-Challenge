import { Component, OnInit } from "@angular/core";
import { CompetitionStoreService } from "../../core/stores/competition-store.service";
import { Competition, CompetitionApiResponse } from "../../models/Competition";
import { BlockUI, NgBlockUI } from "ng-block-ui";
import { CompetitionService } from "src/app/core/services/competition.service";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-competition",
  templateUrl: "./competition.component.html",
  styleUrls: ["./competition.component.css"]
})
export class CompetitionComponent implements OnInit {
  @BlockUI() blockUI: NgBlockUI;

  constructor(
    private competitionStore: CompetitionStoreService,
    private competitionService: CompetitionService,
    private toastr: ToastrService
  ) {
    this.blockUI.start("Loading...");
  }

  public competitions: Competition[];
  private importedCompetitionsIds: number[] = [];
  public apiCompetitions: Competition[];
  //These are the competitions that my free account on Football-Data Api allow me to get info
  private availableCompetitions = [2001, 2002, 2003, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2021];
  ngOnInit() {
    this.getInitialData();
  }

  getInitialData() {
    this.competitionStore.competitions$.subscribe(competitions => {
      this.competitions = competitions;
      this.setImportedCompetitionsIds();
      this.competitionService.GetApiCompetitions().subscribe((res: CompetitionApiResponse) => {
        this.blockUI.stop();
        this.toastr.success("Competitions successfully loaded", "Success");
        this.apiCompetitions = res.competitions.filter(x => this.availableCompetitions.includes(x.id));
      });
    });
  }

  setImportedCompetitionsIds() {
    this.competitions.map(x => this.importedCompetitionsIds.push(x.id));
  }

  viewDetails(id: number) {
    console.log("View ", id);
  }

  importCompetition(id: number) {
    this.competitionService.ImportCompetition(id).subscribe(
      (res: string) => {
        this.competitionStore.fetchCompetitions();
        this.toastr.success(res, "Success");
      },
      err => {
        this.toastr.error(err.error, "Error");
      }
    );
  }
}
