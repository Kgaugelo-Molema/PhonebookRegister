import {Component, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'AngularWebUi';
  headers: HttpHeaders;
  options: any;

  private entries: any;
  private baseUrl = 'api/phonebook';
  searchInput: string;
  private nameInput: string;
  private bookInput: string;
  private numberInput: string;

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json', Accept: 'q=0.8;application/json;q=0.9' });
    this.options = ({ headers: this.headers });
  }
  ngOnInit(): void {
    this.search();
  }

  search() {
    const promise = new Promise((resolve, reject) => {
      this.http.get(this.baseUrl)
        .toPromise()
        .then(
          res => { // Success
            console.log(res);
            this.populateResults(res);
            resolve();
          }
        );
    });
    return promise;
  }

  addEntry() {
    const promise = new Promise((resolve, reject) => {
      const apiURL = `${this.baseUrl}/${this.nameInput}/${this.numberInput}/${this.bookInput}`;
      this.http.post(apiURL, null)
        .toPromise()
        .then(
          res => { // Success
            console.log(res);
            this.search();
            resolve();
          }
        );
    });
    return promise;
  }

  private populateResults(res) {
    this.entries = [];
    if (this.searchInput === '' || this.searchInput === undefined) {
      this.entries = res;
    } else {
      this.filterResults(res);
    }
  }

  private filterResults(res) {
    (res as []).forEach(item => {
      if (item.phonebook.toLowerCase() === this.searchInput.toLowerCase() ||
      (item.name.toLowerCase() === this.searchInput.toLowerCase())) {
        this.entries.push(item);
      }
    });
  }
}
