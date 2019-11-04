import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/Http";
import { Observable } from "rxjs";
import { Constants } from "../constants";

@Injectable({
  providedIn: "root"
})
export class CompetitionService {
  constructor(private _http: HttpClient) {}

  GetCompetitions(): Observable<any> {
    return this._http.get(Constants.apiRoot + "competition");
  }

  GetCompetitionById(idCompetition): Observable<any> {
    return this._http.get(Constants.apiRoot + `competition/${idCompetition}`, { responseType: "json" });
  }

  ImportCompetition(id: number): Observable<any> {
    return this._http.post(Constants.apiRoot + `competition/${id}`, {}, { responseType: "text" });
  }

  GetApiCompetitions(): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        "X-Auth-Token": "86aebf1fe1ad42d8b41ad1af52dc8f53"
      })
    };
    return this._http.get("https://api.football-data.org/v2/competitions", httpOptions);
  }
}
