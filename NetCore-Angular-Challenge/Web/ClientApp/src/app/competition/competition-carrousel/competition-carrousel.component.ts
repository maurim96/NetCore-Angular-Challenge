import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Competition } from "src/app/models/Competition";

@Component({
  selector: "app-competition-carrousel",
  templateUrl: "./competition-carrousel.component.html",
  styleUrls: ["./competition-carrousel.component.css"]
})
export class CompetitionCarrouselComponent implements OnInit {
  @Input() data: Competition[];
  @Input() title: string;
  @Input() icon: string;
  @Output() onClickEmitter = new EventEmitter();
  constructor() {}

  ngOnInit() {}

  onClick(id: number) {
    this.onClickEmitter.emit(id);
  }
}
