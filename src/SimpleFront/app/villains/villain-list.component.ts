import {Component, Input} from 'angular2/core';
import {HTTP_PROVIDERS} from 'angular2/http';

import 'rxjs/add/operator/map';
import 'rxjs/Rx';

import {Fighter} from '../models/fighter'

@Component({
    selector: 'villain-list',
    template: `
        <h1 style="color:red;">Hive of Villians</h1>
        <table class="table table-striped table-hover">
            <thead>
                <th>Name</th>
                <th>Class</th>
                <th>Select</th>
            </thead>
            <tbody>
                <tr *ngFor="#villain of villains">
                    <td>{{ villain.Name }}</td>
                    <td>{{ villain.Class }}</td>
                    <td>
                        <input #{{villain.Id}} [ngModel]="villain.Selected" type="checkbox" (change)="checkbox(villain)">
                    </td>
                </tr>
            </tbody>
        </table>
    `
})

export class VillainListComponent {
    @Input() villains: Fighter[];
    private errorMessage: string;
    
    checkbox(recipient) {
        recipient.selected = (recipient.selected) ? false : true;
    }
}