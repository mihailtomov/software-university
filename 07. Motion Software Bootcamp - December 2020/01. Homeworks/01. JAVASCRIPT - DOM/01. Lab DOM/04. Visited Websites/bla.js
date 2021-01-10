document.body.innerHTML = `
<div class="wrapper tabled">
    <div class="stage" id="page1">
        <div class="middled">
            <div class="link-1">
                <a href="#">
                    <span class="thin">Soft</span><span class="thick">Uni</span>
                </a>
                <p>visited 1 times</p>
            </div>
            <div class="link-1">
                <a href="#">
                    <span class="thin"></span><span class="thick">Google</span>
                </a>
                <p>visited 2 times</p>
            </div>
            <div class="link-1">
                <a href="#">
                    <span class="thin">You</span><span class="thick">Tube</span>
                </a>
                <p>visited 4 times</p>
            </div>
            <div class="link-1">
                <a href="#">
                    <span class="thick">Wiki</span><span class="thin">pedia</span>
                </a>
                <p>visited 4 times</p>
            </div>

            <div class="link-1">
                <a href="#">
                    <span class="thick">G</span><span class="thin">mail</span>
                </a>
                <p>visited 7 times</p>
            </div>

            <div class="link-1">
                <a href="#">
                    <span class="thick">stack</span><span class="thin">overflow</span>
                </a>
                <p>visited 6 times</p>
            </div>
        </div>
    </div>
</div>
`;

result();

let middled = document.getElementsByClassName('middled');

let link = middled[0].children[5].children[0].click();
let test = middled[0].children[5].children[1].innerHTML;
expect(test).to.equal("visited 7 times");