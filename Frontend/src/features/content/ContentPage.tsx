import { useEffect, useState } from "react";
import type { ContentDto } from "../../types/content";
import { getAllContent } from "../../api/contentApi";
import ContentCard from "../../components/ContentCard";
import Search from "../../components/Search";
import ToggleSwitch from "../../components/ToggleSwitch";
import Pagination from "../../components/Pagination";

const ContentPage = () => {
  const [content, setContent] = useState<ContentDto[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    getAllContent()
      .then(setContent)
      .catch(console.error)
      .finally(() => setLoading(false));
  }, []);

  return (
    <div>
      <div>
        <Search />
      </div>

      <div>
        <ToggleSwitch />
      </div>

      <div className="flex justify-center flex-wrap gap-10 mt-8 ">
        {loading ? (
          <p>Loading ...</p>
        ) : (
          content.map((item) => <ContentCard key={item.id} content={item} />)
        )}
      </div>

      <div>
        <Pagination />
      </div>
    </div>
  );
};

export default ContentPage;
