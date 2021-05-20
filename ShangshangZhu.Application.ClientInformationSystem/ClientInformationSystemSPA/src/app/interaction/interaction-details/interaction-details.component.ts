import { ActivatedRoute, Router } from '@angular/router';
import { InteractionService } from './../../core/services/interaction.service';
import { Interaction } from './../../shared/models/Interaction';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-interaction-details',
  templateUrl: './interaction-details.component.html',
  styleUrls: ['./interaction-details.component.css']
})
export class InteractionDetailsComponent implements OnInit {

  interaction: Interaction | undefined;
  constructor(private interactionService: InteractionService,  private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {

    this.route.params.subscribe(params => {
      if(params['id']){
        this.interactionService.getInteractionDetail(params['id']).subscribe((interaction) => {
          this.interaction = interaction;
        });
      }
    });
  }

   delete(){
    this.route.params.subscribe(params => {
      if(params['id']){
        this.interactionService.delete(params['id']).subscribe(
          (response) => {
            if (response) {
              this.router.navigate(['/interactions']);
            }
        });
      }
    });
  }

}
