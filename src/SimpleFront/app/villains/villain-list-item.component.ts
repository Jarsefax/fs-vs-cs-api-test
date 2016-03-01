import {Component, Input} from 'angular2/core';
import {Fighter} from '../fighter';
import {Router} from 'angular2/router';


@Component({
    selector: 'villain-list-item',
    template: `
        <td>{{ villain.name }}</td>
        <td>{{ villain.class }}</td>
    `
})

export class VillainListItemComponent{
    @Input() villain: Fighter;
    
    constructor() {
    }
}