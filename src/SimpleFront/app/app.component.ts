import {Component} from 'angular2/core';

import {HeroListComponent} from './heroes/hero-list.component';
import {VillainListComponent} from './villains/villain-list.component';

@Component({
    selector: 'my-app',
    template: `
        <hero-list>Loading heroes...</hero-list>
        <villain-list>Loading villains...</villain-list>
    `,
    directives: [HeroListComponent, VillainListComponent]
})

export class AppComponent {}