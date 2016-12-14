import {Component} from '@angular/core';
import {NavController, NavParams} from 'ionic-angular';
import {HomePage} from '../../pages/home/home';

@Component({
    templateUrl: 'build/pages/generate-code/generate-code.html'
})

export class GenerateCode {
    private pages: Array<any>;

    constructor(private nav: NavController, private params: NavParams) {
        this.pages = [HomePage];
    }

    ngOnInit() {
        //Generate QR Code here
    }

    return() {
        this.nav.push(this.pages[0]);
    }
}