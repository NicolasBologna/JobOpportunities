import {
  Component,
  EventEmitter,
  OnInit,
  Output,
  Input,
  ViewChild,
  ElementRef,
  OnChanges,
  SimpleChanges,
} from '@angular/core';
import { JobOffer } from 'src/app/common/models/job-offer';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { SkillsRepositoryService } from 'src/app/common/services/skills-repository.service';
import { Skill } from 'src/app/common/models/skill';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { map, Observable, startWith } from 'rxjs';

@Component({
  selector: 'app-job-offer-details',
  templateUrl: './job-offer-details.component.html',
  styleUrls: ['./job-offer-details.component.scss'],
})
export class JobOfferDetailsComponent implements OnInit, OnChanges {
  creationForm: FormGroup;

  currentJobOffer: JobOffer;
  availableSkills: Skill[];
  selectedSkills: string[] = [];
  originalTitle = '';
  minDate = new Date();

  @Output() saved = new EventEmitter();
  @Output() cancelled = new EventEmitter();
  @Input() set jobOffer(value) {
    if (!value) return;
    this.currentJobOffer = JSON.parse(JSON.stringify(value));
    this.originalTitle = value.title;
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (!changes.jobOffer.isFirstChange())
      this.creationForm.setValue(this.currentJobOffer);
  }

  constructor(private skillService: SkillsRepositoryService) {}

  ngOnInit(): void {
    this.minDate.setDate(this.minDate.getDate() + 1);

    this.creationForm = new FormGroup({
      id: new FormControl(this.currentJobOffer.id),
      title: new FormControl(this.currentJobOffer.title, [Validators.required]),
      description: new FormControl(this.currentJobOffer.description),
      validUntil: new FormControl(this.currentJobOffer.validUntil, [
        Validators.required,
      ]),
      requiredSkills: new FormControl(
        this.currentJobOffer.requiredSkills,
        Validators.required
      ),
    });

    this.skillService.getSkillLevels('skill').subscribe((res) => {
      this.availableSkills = res;
      this.filteredSkills = this.requiredSkills.valueChanges.pipe(
        startWith(null),
        map((skills: Skill[] | null) =>
          skills ? this._filter(skills) : this.availableSkills.slice()
        )
      );
    });
  }

  focusOutFunction() {
    this.skillNameInput.nativeElement.value = '';
  }

  filteredSkills: Observable<Skill[]>;

  @ViewChild('skillNameInput') skillNameInput: ElementRef<HTMLInputElement>;

  remove(skillName: string): void {
    const index = this.requiredSkills.value.indexOf(skillName);

    if (index >= 0) {
      this.requiredSkills.value.splice(index, 1);
      this.requiredSkills.updateValueAndValidity();
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    this.requiredSkills.value.push(event.option.value);
    this.skillNameInput.nativeElement.value = '';
    this.requiredSkills.updateValueAndValidity();
  }

  private _filter(value: Skill[]): Skill[] {
    console.log(value);

    const filterValues = value.map((selectedSkill) =>
      selectedSkill.name.toLowerCase()
    );

    return this.availableSkills.filter(
      (skill) => !filterValues.includes(skill.name.toLowerCase())
    );
  }

  get requiredSkills() {
    return this.creationForm.get('requiredSkills');
  }
}
