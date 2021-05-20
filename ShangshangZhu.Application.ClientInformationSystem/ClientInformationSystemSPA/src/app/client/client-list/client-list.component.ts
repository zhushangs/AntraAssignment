import { ActivatedRoute } from '@angular/router';
import { ClientService } from './../../core/services/client.service';
import { Client } from './../../shared/models/Client';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {

  clients: Client[] | undefined;
  constructor(private clientService: ClientService, private router: ActivatedRoute) { }

  ngOnInit(): void {
    this.clientService.getAllClients()
    .subscribe(
      c => {
        this.clients = c
      })
  }

}
