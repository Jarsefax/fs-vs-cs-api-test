import {Component, Input} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';

import 'rxjs/add/operator/map';
import 'rxjs/Rx';

import {Fighter} from '../models/fighter'

@Component({
    selector: 'hero-list',
    template: `
        <h1 style="color:blue;">Altar of Heroes</h1>
        <table class="table table-striped table-hover">
            <thead>
                <th>Name</th>
                <th>Class</th>
                <th>Select</th>
            </thead>
            <tbody>
                <tr *ngFor="#hero of heroes">
                    <td>{{ hero.Name }}</td>
                    <td>{{ hero.Class }}</td>                    
                    <td>
                        <input #{{hero.Id}} [ngModel]="hero.Selected" type="checkbox" (change)="checkbox(hero)">
                    </td>
                </tr>
            </tbody>
        </table>
    `
})

export class HeroListComponent {
    @Input() heroes: Fighter[];
    
    checkbox(recipient) {
        recipient.selected = (recipient.selected) ? false : true;
    }
}