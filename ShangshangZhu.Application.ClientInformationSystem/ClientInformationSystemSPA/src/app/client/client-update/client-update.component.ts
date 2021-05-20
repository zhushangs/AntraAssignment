import { AddClient } from './../../shared/models/AddClient';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientService } from './../../core/services/client.service';
import { Client } from './../../shared/models/Client';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-client-update',
  templateUrl: './client-update.component.html',
  styleUrls: ['./client-update.component.css']
})
export class ClientUpdateComponent implements OnInit {

  client: AddClient = {
    name: '',
    email: '',
    phones: '',
    address: '',
    addedBy: 0,
  }
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
  
  update(){
    this.clientService.update(this.client).subscribe(
          (response) => {
            if (response) {
              this.router.navigate(['/clients']);
            }else{
              console.log("error");
            }
          },
    );
  }
    get twoWayBindingInfo(){
    return JSON.stringify(this.client);
  }
}
