import { InteractionService } from './../../core/services/interaction.service';
import { AddInteraction } from './../../shared/models/AddInteraction';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-interaction-create',
  templateUrl: './interaction-create.component.html',
  styleUrls: ['./interaction-create.component.css']
})
export class InteractionCreateComponent implements OnInit {

  addInteraction: AddInteraction = {
      clientId: 0,
      empId: 0,
      type: '',
      date: new Date(),
      remarks: '',
  }
  constructor(private router: Router, private interactionService: InteractionService) { }

  ngOnInit(): void {
  }
  
  Add(){
      this.interactionService.create(this.addInteraction).subscribe(
        (response) => {
          if (response) {
            this.router.navigate(['/interactions']);
          }
        }
      );
    }
}
