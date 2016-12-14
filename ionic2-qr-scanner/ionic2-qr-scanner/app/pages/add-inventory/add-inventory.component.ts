import {Component} from '@angular/core';
import {NavController} from 'ionic-angular';
import {GenerateCode} from '../../pages/generate-code/generate-code.component';

@Component({
    templateUrl: 'build/pages/add-inventory/add-inventory.html'
})

export class AddInventory {
    private pages: Array<any>;

    constructor(private nav: NavController) {
        this.pages = [GenerateCode];
    }
    
    addItem() {
        //Call POST method in API to save new item info
        //then pass the data retrieved from query to next page for QR code generation
        this.nav.push(this.pages[0]);
    }
}