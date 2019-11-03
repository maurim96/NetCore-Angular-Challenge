import { Component, OnInit } from "@angular/core";
import { CompetitionStoreService } from '../../core/stores/competition-store.service';
import { Competition } from '../../models/Competition';
import { BlockUI, NgBlockUI } from "ng-block-ui";

@Component({
  selector: "app-competition",
  templateUrl: "./competition.component.html",
  styleUrls: ["./competition.component.css"]
})
export class CompetitionComponent implements OnInit {
  @BlockUI() blockUI: NgBlockUI;

  constructor(private competitionStore: CompetitionStoreService) {
    this.blockUI.start('Loading...');
  }

  private competitions: Competition[];

  ngOnInit() {
    this.competitionStore.competitions$.subscribe(competitions => {
      this.blockUI.stop();
      this.competitions = competitions;
    });
  }
}
