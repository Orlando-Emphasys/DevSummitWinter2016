import {Component} from '@angular/core';
import {NavController, NavParams} from 'ionic-angular';
import {Http} from '@angular/http';
import {HomePage} from '../../pages/home/home';

@Component({
    templateUrl: 'build/pages/generate-code/generate-code.html'
})

export class GenerateCode {
    private pages: Array<any>;

    constructor(private nav: NavController, private params: NavParams, private http: Http) {
        this.pages = [HomePage];
    }

    //ngOnInit() {
    //    //Generate QR Code here
    //    this.http.get("https://chart.googleapis.com/chart?cht=qr&chs=150x150&chl=WeDidIt").subscribe(
    //        response => {
    //            console.log(response);
    //        },
    //        err => {
    //            console.log('Error: ' + err);   
    //        }
    //    )
    //}

    return() {
        this.nav.push(this.pages[0]);
    }
}