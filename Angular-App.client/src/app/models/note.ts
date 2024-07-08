import { IdMongo } from "./idMongo"

export interface Note {
  id: IdMongo | null,
  content: string,
  patientId: number
}
