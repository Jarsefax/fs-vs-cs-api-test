import {Component, ElementRef, AppViewManager} from 'angular2/core';
import {Headers, RequestOptions} from 'angular2/http';
import {Http, Response} from 'angular2/http';

import {VillainService} from './villains/service/villain.service'
import {HeroService} from './heroes/service/hero.service'

import {HeroListComponent} from './heroes/hero-list.component';
import {VillainListComponent} from './villains/villain-list.component';

import {Battle} from './models/battle'
import {BattleResult} from './models/result'
import {Fighter} from './models/fighter'

import 'rxjs/add/operator/map';
import 'rxjs/Rx';

@Component({
    selector: 'my-app',
    template: `
        <hero-list [heroes]=heroes>Loading heroes...</hero-list>
        <villain-list [villains]=villains>Loading villains...</villain-list>
        <button (click)="onClickIt()">Commence Battling!</button>
        <hr>
        <h2 style="color:green;">Battle Result</h2>
        <h1>{{battleResult}}</h1>
        <h2 style="color:orange;">Fighters left standing</h2>
        <table class="table table-striped table-hover">
            <thead>
                <th>Name</th>
            </thead>
            <tbody>
                <tr *ngFor="#fighter of fighters">
                    <td>{{ fighter.Name }}</td>
                </tr>
            </tbody>
        </table>
    `,
    directives: [HeroListComponent, VillainListComponent],
    providers: [VillainService, HeroService]
})

export class AppComponent {
    private _url = "http://localhost:48213/api/battle";
    
    private villains: Fighter[];
    private heroes: Fighter[];
    private fighters: Fighter[];
    private battleResult: string;
    private errorMessage: string;
    
    constructor (
        private http: Http, 
        private _villainService: VillainService,
        private _heroService: HeroService) {}
    
    ngOnInit() {
        this._villainService
            .getList()
            .subscribe(
                villains => this.villains = villains,
                error =>  this.errorMessage = <any>error);
                        
        this._heroService
            .getList()
            .subscribe(
                heroes => this.heroes = heroes,
                error =>  this.errorMessage = <any>error);
    }    
    
    onClickIt() {
        let battle = 
            new Battle(
                this.heroes
                    .filter(h => h.selected)
                    .map(h => h.Id), 
                this.villains
                    .filter(h => h.selected)
                    .map(h => h.Id));
        
        let body = JSON.stringify(battle);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http
                    .post(this._url, body, options)
                    .map(res => res.json())
                    .subscribe(
                        data => this.handleResult(data)
                    );
    }
    
    handleResult(data) {
        this.battleResult = data.ResultMessage;
    }
    
    catchError(err) {
        let temp = err;
    }
}