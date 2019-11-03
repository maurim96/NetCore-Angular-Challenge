import { Injectable } from '@angular/core';
import { BehaviorSubject } from "rxjs";
import { CompetitionService } from '../services/competition.service';
import { Competition } from '../../models/Competition';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class CompetitionStoreService {

  constructor(private competitionService: CompetitionService, private toastr: ToastrService) {
    this.fetchCompetitions();
   }

   private readonly _competitions = new BehaviorSubject<Competition[]>([]);

  readonly competitions$ = this._competitions.asObservable();

  get competitions(): Competition[] {
    return this._competitions.getValue();
  }

  set competitions(val: Competition[]) {
    this._competitions.next(val);
  }

  addCompetition(competition: Competition) {
    this.competitions = [...this.competitions, competition];
  }

  removeCompetition(id: number) {
    this.competitions = this.competitions.filter(competition => competition.id !== id);
  }

  removeAllCompetitions(id) {
    this.competitions = this.competitions.filter(competition => competition.id != id);
  }

  editReminder(competition: Competition) {
    const compSaved = this.competitions.find(x => x.id === competition.id);
    const index = this.competitions.indexOf(compSaved);

    this.competitions[index] = {
      ...competition
    };

    this.competitions = [...this.competitions];
  }

  fetchCompetitions() {
    this.competitionService.GetCompetitions().subscribe(res => {
      this.competitions = res;
      this.toastr.success('Competitions successfully loaded', 'Success');
    });
  }
}