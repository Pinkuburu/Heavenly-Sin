using HeavenlySin.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace HeavenlySin.Gameplay.UI
{
    public class JournalController : MonoBehaviour
    {
        #region Public Fields
        
        public GameObject backButton;
        public Text firstPageTitle;
        public Text firstPageTitleOutline;
        public Journal journal;
        public GameObject nextButton;
        public GameObject portraitBorder;
        public GameObject portrait;
        public Text relationsText;
        //public Text relationsOutline;
        public Text secondPageTitle;
        public Text secondPageTitleOutline;
        public Text testimonyText;
        //public Text testimonyOutline;
        public UIManager uiManager;
        
        #endregion

        #region Private Fields
        
        private int _pageIndex;
        
        #endregion
 
        #region LifeCycle
        private void Start()
        {
            // Starts Journal on First Page: Objective
            _pageIndex = 0;
            Journal();
        }
 
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                uiManager.PauseResume(3);
            } 
        }
        #endregion

        #region Public Methods

        private void UpdateFirstPageTitle()
        {
            firstPageTitle.text = journal.pages[_pageIndex].leftPageTitle;
            firstPageTitleOutline.text = journal.pages[_pageIndex].leftPageTitle;
        }

        private void UpdateSecondPageTitle()
        {
            secondPageTitle.text = journal.pages[_pageIndex].rightPageTitle;
            secondPageTitleOutline.text = journal.pages[_pageIndex].rightPageTitle;
        }

        // TODO: The "TESTIMONIES" and "RELATIONS" text will show up in the  objective. This probably isn't favorable.
        // TODO: Can make a check if _pageIndex == 0 probably.
        private void UpdateTestimonies()
        {
            if (_pageIndex == 0)
            {
                testimonyText.text = "TO DO LIST: ";
            }
            else
            {
                testimonyText.text = "TESTIMONIES: ";
            }
            
            foreach (var t in journal.pages[_pageIndex].testimonies)
            {
                // TODO: Might want to do some sort of formatting. I'm not sure how you could get bullet points here.
                testimonyText.text += "\n" + t + "\n";
            }
        }

        private void UpdateRelations()
        {
            if (_pageIndex == 0)
            {
                relationsText.text = "HINTS: ";
            }
            else
            {
                relationsText.text = "RELATIONS: ";
            }

            foreach (var t in journal.pages[_pageIndex].relations)
            {
                // TODO: Might want to do some sort of formatting. I'm not sure how you could get bullet points here.
                relationsText.text += "\n" + t;
            }
        }
        
        private void Journal()
        {
            // Show the relevant buttons on the journal.
            backButton.SetActive(true);
            nextButton.SetActive(true);
            // Show portrait outline o nthe journal.
            portraitBorder.SetActive(true);
            if (_pageIndex == 0)
            {
                backButton.SetActive(false);
                portraitBorder.SetActive(false);

            }
            if (_pageIndex == journal.pages.Length - 1)
            {
                nextButton.SetActive(false);
            }
            
            // Update the information in the journal.
            portrait.GetComponent<Image>().sprite = journal.pages[_pageIndex].portrait;
            UpdateFirstPageTitle();
            UpdateSecondPageTitle();
            UpdateTestimonies();
            UpdateRelations();
        }
        
        public void PageBack()
        {
            _pageIndex--;
            Journal();
        }

        public void PackNext()
        {
            _pageIndex++;
            Journal();
        }
        
        #endregion 

        #region Private Methods
        #endregion
    }
}