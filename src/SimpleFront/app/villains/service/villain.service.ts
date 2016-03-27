import {Injectable} from 'angular2/core';
import {Http, Response} from 'angular2/http';

import {Observable} from 'rxjs/Observable';

import {Fighter} from '../../models/fighter'

import 'rxjs/add/operator/map';
import 'rxjs/Rx';

@Injectable()
export class VillainService {
    constructor (private http: Http) {}
    
    private handleError (error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
    
    private _villainsUrl = 'http://localhost:51771/api/villain';
    getList() {
       return this.http.get(this._villainsUrl)
                    .map(res => <Fighter[]> res.json())
                    .catch(this.handleError);   
    }
}