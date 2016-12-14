import {Component} from '@angular/core';
import {NavController, NavParams} from 'ionic-angular';

@Component({
    templateUrl: 'build/pages/details-page/details-page.html'
})

export class DetailsPage {
    private retrievedItem: any;

    constructor(private nav: NavController, private params: NavParams) {
        console.log(params.get('item'));

        this.retrievedItem = params.get('item');
    }
}