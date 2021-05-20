import { ActivatedRoute, Router } from '@angular/router';
import { ClientService } from './../../core/services/client.service';
import { Client } from './../../shared/models/Client';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-client-details',
  templateUrl: './client-details.component.html',
  styleUrls: ['./client-details.component.css']
})
export class ClientDetailsComponent implements OnInit {

  client : Client | undefined;
  constructor(private clientService: ClientService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      if(params['id']){
        this.clientService.getClientDetail(params['id']).subscribe((client) => {
          this.client = client;
        });
      }
    });
  }

  delete(){
    this.route.params.subscribe(params => {
      if(params['id']){
        this.clientService.delete(params['id']).subscribe(
          (response) => {
            if (response) {
              this.router.navigate(['/clients']);
            }
        });
      }
    });
  }
}
