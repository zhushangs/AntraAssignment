import { AddClient } from './../../shared/models/AddClient';
import { ClientService } from './../../core/services/client.service';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-client-create',
  templateUrl: './client-create.component.html',
  styleUrls: ['./client-create.component.css']
})
export class ClientCreateComponent implements OnInit {

  addClient: AddClient = {
      name: '',
      email: '',
      phones: '',
      address: '',
      addedBy: 0,
  }

  constructor(private router: Router, private clientService: ClientService) { }

  ngOnInit(): void {
  }

  Add(){
    this.clientService.create(this.addClient).subscribe(
      (response) => {
        if (response) {
          this.router.navigate(['/clients']);
        }
      }
    );
  }
}
