export type ContentType = "Movie" | "TVShow";

export interface ContentDto {
  id: string;
  title: string;
  description: string;
  releaseDate: string;
  type: ContentType;
  imageType: string;
}
