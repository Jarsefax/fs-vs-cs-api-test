import {Component, Input} from 'angular2/core';
import {Fighter} from '../fighter';
import {Router} from 'angular2/router';


@Component({
    selector: 'hero-list-item',
    template: `
        <td>{{ hero.name }}</td>
        <td>{{ hero.class }}</td>
    `
})

export class HeroListItemComponent{
    @Input() hero: Fighter;
    
    constructor() {
    }
}