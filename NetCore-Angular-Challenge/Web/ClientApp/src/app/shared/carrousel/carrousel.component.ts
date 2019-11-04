import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Competition } from "src/app/models/Competition";

@Component({
  selector: "app-carrousel",
  templateUrl: "./carrousel.component.html",
  styleUrls: ["./carrousel.component.css"]
})
export class CarrouselComponent implements OnInit {
  @Input() data: Competition[];
  @Input() title: string;
  @Input() icon: string;
  @Input() img: string;
  @Output() onClickEmitter = new EventEmitter();
  constructor() {}

  ngOnInit() {}

  onClick(id: number) {
    this.onClickEmitter.emit(id);
  }
}
