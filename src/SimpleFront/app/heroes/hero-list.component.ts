import {Component, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';

import 'rxjs/add/operator/map';
import 'rxjs/Rx';

import {HeroListItemComponent} from './hero-list-item.component';

import {Fighter} from '../fighter'
import {HeroService} from './service/hero.service'

@Component({
    selector: 'hero-list',
    template: `
        <h1>Altar of Heroes</h1>
        <ul>
    <li *ngFor="#hero of heroes">
      {{ hero.name }}
    </li>
  </ul>
    `,
    directives: [HeroListItemComponent],
    providers: [HeroService]
})

export class HeroListComponent implements OnInit {
    heroes: Fighter[];
    errorMessage: string;
    
    constructor(private _heroService: HeroService) { }
    
    getList() {
        this._heroService.getList()
                     .subscribe(
                        heroes => this.heroes = heroes,
                        error =>  this.errorMessage = <any>error);
    }

    ngOnInit() {
        this.getList();
    }
}