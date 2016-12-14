import {Component} from '@angular/core';
import {NavController} from 'ionic-angular';
import {BarcodeScanner} from 'ionic-native';
import {Http, Headers} from '@angular/http';
import {AddInventory} from '../../pages/add-inventory/add-inventory.component';
import {DetailsPage} from '../../pages/details-page/details-page.component';

@Component({
  templateUrl: 'build/pages/home/home.html'
})

export class HomePage {
    private pages: Array<any>;
    private item1: InventoryItem;
    private item2: InventoryItem;
    private item3: InventoryItem;
    private item4: InventoryItem;
    private item5: InventoryItem;
    private itemList: Array<InventoryItem>;

    constructor(private nav: NavController, private http: Http) {
        this.pages = [AddInventory, DetailsPage];

        this.item1 = new InventoryItem();
        this.item2 = new InventoryItem();
        this.item3 = new InventoryItem();
        this.item4 = new InventoryItem();
        this.item5 = new InventoryItem();

        this.item1.type = 'Laptop';
        this.item1.serialNum = '15GDFA4DD5S4FS4AB5Z5';
        this.item1.brand = 'Dell';
        this.item1.model = 'Latitude E6650';
        this.item1.officename = 'Miami';

        this.item2.type = 'Chair'
        this.item2.serialNum = '1D5B5A1D8SF1Q51F5S';
        this.item2.brand = 'Wooden';
        this.item2.model = 'Regular';
        this.item2.officename = 'Miami';

        this.item3.type = 'Laptop';
        this.item3.serialNum = '54DF84SADF5ADF48S6A'
        this.item3.brand = 'Dell';
        this.item3.model = 'Latitude E6540';
        this.item3.officename = 'Petoskey';

        this.item4.type = 'Phone';
        this.item4.serialNum = '5DF51A8DF5';
        this.item4.brand = 'Cisco';
        this.item4.model = 'VoIP 3420';
        this.item4.officename = 'Emeryville';

        this.item5.type = 'Printer';
        this.item5.serialNum = '3DF4A8SD4F1B85A5DF8';
        this.item5.brand = 'HP';
        this.item5.model = 'OfficeJet 8400';
        this.item5.officename = 'Palma de Mallorca';

        this.itemList = [this.item1, this.item2, this.item3, this.item4, this.item5];
    }

    //ngOnInit() {
        
    //    //Query for the top 20 records in database without filter
    //    this.http.get("http://qrscannerapi.azurewebsites.net/api/inventory/listmodels/").subscribe(
    //        response => {
    //            console.log(response);
    //        },
    //        err => {
    //            console.log('Error: ' + err);
    //        }

    //    );
    //}

    //filterList(office: string) {
    //    //Write code to filter the list when an office is selected
    //}

    addInventory() {
        this.nav.push(this.pages[0]);
    }

    scan() {
        BarcodeScanner.scan().then((data) => {
            //Make call to API with Id, get data from API
            var results = JSON.parse(data.text).item;

            console.log(results);
            console.log(results.serialnumber);

            let retrieved = new InventoryItem();
            retrieved.serialNum = results.serialnumber;
            retrieved.brand = results.brand;
            retrieved.model = results.model;
            retrieved.type = results.type;
            retrieved.quantity = results.quantity;
            retrieved.location = results.location;
            retrieved.officename = results.office;
            retrieved.ownername = results.owner;

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