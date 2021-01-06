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

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json', Accept: 'q=0.8;application/json;q=0.9' });
    this.options = ({ headers: this.headers });
  }
  ngOnInit(): void {
    this.search('');
    
  }

  search(term: string) {
    const promise = new Promise((resolve, reject) => {
      const apiURL = 'api/phonebook';
      this.http.get(apiURL)
        .toPromise()
        .then(
          res => { // Success
            console.log(res);
            this.entries = res;
            resolve();
          }
        );
    });
    return promise;
  }
}
