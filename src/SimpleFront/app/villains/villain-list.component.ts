import {Component, OnInit} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';

import 'rxjs/add/operator/map';
import 'rxjs/Rx';

import {VillainListItemComponent} from './villain-list-item.component';

import {Fighter} from '../fighter'
import {VillainService} from './service/villain.service'

@Component({
    selector: 'villain-list',
    template: `
        <h1>Hive of Villians</h1>
        <table class="table table-striped table-hover">
            <thead>
                <th>Name</th>
                <th>Class</th>
            </thead>
            <tbody>
                <tr *ngFor="#villian of villians">
                    <villain-list-item [villain]="villain"></villain-list-item>
                </tr>
            </tbody>
        </table>
    `,
    directives: [VillainListItemComponent],
    providers: [VillainService]
})

export class VillainListComponent implements OnInit {
    villains: Fighter[];
    errorMessage: string;
    
    constructor(private _villainService: VillainService) { }
    
    getList() {
        this._villainService.getList()
                     .subscribe(
                        villains => this.villains = villains,
                        error =>  this.errorMessage = <any>error);
        console.log(this.villains);
        console.log('er');
    }

    ngOnInit() {
        this.getList();
    }
}