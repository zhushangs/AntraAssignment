import { ActivatedRoute } from '@angular/router';
import { InteractionService } from './../../core/services/interaction.service';
import { Interaction } from './../../shared/models/Interaction';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-interaction-list',
  templateUrl: './interaction-list.component.html',
  styleUrls: ['./interaction-list.component.css']
})
export class InteractionListComponent implements OnInit {

  interactions: Interaction[] | undefined;
  constructor(private interactionService: InteractionService, private router: ActivatedRoute) { }

  ngOnInit(): void {
    this.interactionService.getAllInteractions()
    .subscribe(
      i => {
        this.interactions = i
      })
  }

}
