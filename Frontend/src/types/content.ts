export type ContentType = "Movie" | "TVShow";

export type ContentDto = {
  id: string;
  title: string;
  description: string;
  releaseDate: string;
  type: ContentType;
  imageURL: string;
};
