import {
  Component,
  EventEmitter,
  OnInit,
  Output,
  Input,
  ViewChild,
  ElementRef,
} from '@angular/core';
import { JobOffer } from 'src/app/common/models/job-offer';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { SkillsRepositoryService } from 'src/app/common/services/skills-repository.service';
import { Skill } from 'src/app/common/models/skill';
import {
  FormControl,
  FormGroup,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { map, Observable, startWith } from 'rxjs';

@Component({
  selector: 'app-job-offer-details',
  templateUrl: './job-offer-details.component.html',
  styleUrls: ['./job-offer-details.component.scss'],
})
export class JobOfferDetailsComponent implements OnInit {
  creationForm: FormGroup;

  currentJobOffer: JobOffer;
  availableSkills: Skill[];
  skillNames: string[];
  selectedSkills: string[] = [];
  originalTitle = '';

  @Output() saved = new EventEmitter();
  @Output() cancelled = new EventEmitter();
  @Input() set jobOffer(value) {
    if (!value) return;
    this.currentJobOffer = { ...value };
    this.originalTitle = value.title;
  }

  constructor(private skillService: SkillsRepositoryService) {}

  ngOnInit(): void {
    this.creationForm = new FormGroup({
      title: new FormControl('', [Validators.required]),
      description: new FormControl(''),
      validUntil: new FormControl(new Date(), [Validators.required]),
      requiredSkillsIds: new FormControl([], Validators.required),
    });

    this.skillService.getSkillLevels('skill').subscribe((res) => {
      this.availableSkills = res;
      this.skillNames = this.availableSkills.map((s) => s.name);
      this.filteredSkills = this.requiredSkillsIds.valueChanges.pipe(
        startWith(null),
        map((skill: string[] | null) =>
          skill ? this._filter(skill) : this.skillNames.slice()
        )
      );
    });
  }

  focusOutFunction() {
    this.skillNameInput.nativeElement.value = '';
  }

  filteredSkills: Observable<string[]>;

  @ViewChild('skillNameInput') skillNameInput: ElementRef<HTMLInputElement>;

  // add(event: MatChipInputEvent): void {
  //   const value = (event.value || '').trim();
  //   console.log(value);

  //   // Add our fruit
  //   if (value) {
  //     this.requiredSkillsIds.value.push(value);
  //   }

  //   // Clear the input value
  //   event.chipInput!.clear();
  // }

  remove(skillName: string): void {
    const index = this.requiredSkillsIds.value.indexOf(skillName);

    if (index >= 0) {
      this.requiredSkillsIds.value.splice(index, 1);
      this.requiredSkillsIds.updateValueAndValidity();
    }
  }

  selected(event: MatAutocompleteSelectedEvent): void {
    this.requiredSkillsIds.value.push(event.option.viewValue);
    this.skillNameInput.nativeElement.value = '';
    this.requiredSkillsIds.updateValueAndValidity();
  }

  private _filter(value: string[]): string[] {
    console.log(value);

    const filterValues = value.map((selectedSkill) =>
      selectedSkill.toLowerCase()
    );

    return this.skillNames.filter(
      (skill) => !filterValues.includes(skill.toLowerCase())
    );
  }

  get requiredSkillsIds() {
    return this.creationForm.get('requiredSkillsIds');
  }
}
