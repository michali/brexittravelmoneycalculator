import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import { ICountry } from "./country";
import { environment } from '../../environments/environment';

@Injectable()
export class VerdictService {
    private _countryUrl = environment.apiUrl + '/api/verdict?countryId=';

    constructor(private _http: Http) {}

    getVerdict(countryId:string): Observable<ICountry> {
        return this._http.get(`${this._countryUrl}${countryId}`)
            .map((response: Response) => <ICountry> response.json())
            .do(data => console.log('All: ' +  JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}
