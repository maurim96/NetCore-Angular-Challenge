import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/Http';
import { Observable } from 'rxjs';
import { Constants } from '../constants';

@Injectable({
  providedIn: 'root'
})
export class CompetitionService {

  constructor(private _http: HttpClient) { }

  GetCompetitions(): Observable<any> {
    return this._http.get(Constants.apiRoot + 'competition');
  }
}
