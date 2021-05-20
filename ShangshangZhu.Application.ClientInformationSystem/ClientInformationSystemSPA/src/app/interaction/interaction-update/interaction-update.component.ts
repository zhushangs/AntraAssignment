import { InteractionService } from './../../core/services/interaction.service';
import { AddInteraction } from './../../shared/models/AddInteraction';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-interaction-update',
  templateUrl: './interaction-update.component.html',
  styleUrls: ['./interaction-update.component.css']
})
export class InteractionUpdateComponent implements OnInit {

  interaction: AddInteraction = {
      clientId: 0,
      empId: 0,
      type: '',
      date: new Date(),
      remarks: '',
  }
  constructor(private interactionService: InteractionService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      if(params['id']){
        this.interactionService.getInteractionDetail(params['id']).subscribe((interaction) => {
          this.interaction = interaction;
        });
      }
    });
  }

  update(){
    this.interactionService.update(this.interaction).subscribe(
          (response) => {
            if (response) {
              this.router.navigate(['/interactions']);
            }else{
              console.log("error");
            }
          },
    );
  }

}
