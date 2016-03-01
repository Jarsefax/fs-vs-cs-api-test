import {Injectable} from 'angular2/core';
import {Http, Response} from 'angular2/http';

import {Observable} from 'rxjs/Observable';

import {Fighter} from '../../fighter'

import 'rxjs/add/operator/map';
import 'rxjs/Rx';

@Injectable()
export class HeroService {
    constructor (private http: Http) {}
    
    private handleError (error: Response) {
        // in a real world app, we may send the error to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
    
    private _heroesUrl = 'http://localhost:58175/api/heroes';
    getList() {
       return this.http.get(this._heroesUrl)
                    .map(res => <Fighter[]> res.json())
                    // .do(data => console.log(data))
                    .catch(this.handleError);   
    }
}