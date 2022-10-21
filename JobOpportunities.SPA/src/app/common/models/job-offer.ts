import { Skill } from './skill';

export interface JobOffer {
  id: string;
  title: string;
  description: string;
  validUntil: Date | string;
  companyId: string;
  requiredSkills?: Skill[];
  candidates?: [];
}
