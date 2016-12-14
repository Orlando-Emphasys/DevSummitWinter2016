import {Component} from '@angular/core';
import {NavController} from 'ionic-angular';
import {BarcodeScanner} from 'ionic-native';
import {Http} from '@angular/http';
import {AddInventory} from '../../pages/add-inventory/add-inventory.component';
import {DetailsPage} from '../../pages/details-page/details-page.component';

@Component({
  templateUrl: 'build/pages/home/home.html'
})

export class HomePage {
    private pages: Array<any>;
    private itemList: Array<InventoryItem>;

    constructor(private nav: NavController, private http: Http) {
        this.pages = [AddInventory, DetailsPage];
    }

    ngOnInit() {
        //Query for the top 20 records in database without filter
        this.http.get("http://qrscannerapi.azurewebsites.net/api/inventory/miami");
    }

    filterList(office: string) {
        //Write code to filter the list when an office is selected
    }

    addInventory() {
        this.nav.push(this.pages[0]);
    }

    scan() {
        BarcodeScanner.scan().then((data) => {
            //Make call to API with Id, get data from API
            let retrieved = new InventoryItem();
            console.log(data);

            //Show readonly view and pass data into it for display
            this.nav.push(this.pages[1], {
                item: retrieved
            });

        }, (err) => {
            //Create toast displaying error message
            console.log('Error: ' + err);
        });
    }
}

class InventoryItem {
    public brand: string;
    public quantity: number;
    public ownername: string;
    public type: string;
    public model: string;
    public officename: string;
    public location: string;
    public serialNum: string;
}